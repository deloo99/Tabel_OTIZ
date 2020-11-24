using Microsoft.Office.Interop.Excel;
using OTIZ_Tabel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OTIZ_Tabel.Classes
{
    public static class LaborIntensityUpdater
    {
        public static void SetWeldedAssembliesList(LoggerForm logger)
        {
            try
            {
                logger.DefaultBoldText("Подготовка к работе.");
                var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                var usedRange = (object[,])worksheet.UsedRange.get_Value(Type.Missing);
                var settings = Properties.Settings.Default.WeldedAssembliesSetting.Split().Select((x, i) => (Value: int.Parse(x), Group: i / 4))
                    .GroupBy(x => x.Group).Where(x => x.All(x => x.Value > 0)).Select(x => x.Select(y => y.Value).ToArray()).ToArray();
                if (settings.Length <= 0 || !settings.All(x => x.Max() < usedRange.GetLength(1)))
                {
                    logger.ErrorText(" ⚠ НАСТРОЙКИ НЕ КОРРЕКТНЫ\r\n");
                    return;
                }
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n\r\n");

                logger.DefaultBoldText($"Сбор данных:\r\n");
                var laborIntensityList = LoadLaborIntensityList(logger, Properties.Settings.Default.WAMainDirectoryPath
                    , Properties.Settings.Default.WAExcelFileName);
                logger.SuccessText($"Загружено {laborIntensityList.Count} записей\r\n\r\n");
                if (logger.IsClosed) return;

                logger.DefaultBoldText($"Заполнение таблицы:\r\n");
                int rowCount = usedRange.GetLength(0);
                for (int row = 1; row <= rowCount; row++)
                {
                    foreach (var setting in settings)
                    {
                        // 0 - заказ, 1 - марка, 2 - группа, 3 - норма
                        // if (setting.All(x => usedRange[row, x] != null))
                        if (usedRange[row, setting[0]] != null && usedRange[row, setting[1]] != null && usedRange[row, setting[2]] != null)
                        {
                            var laborIntensity = laborIntensityList.FirstOrDefault(x => x.Order == usedRange[row, setting[0]].ToString()
                                && x.Mark == usedRange[row, setting[1]].ToString());
                            if (laborIntensity != null)
                            {
                                double? value = worksheet.Cells[row, setting[3]] = (usedRange[row, setting[2]].ToString()) switch
                                {
                                    "НО" => laborIntensity.NO1,
                                    "НО1" => laborIntensity.NO1,
                                    "НО1.1" => laborIntensity.NO11,
                                    "НО2" => laborIntensity.NO2,
                                    "НО2.1" => laborIntensity.NO21,
                                    "ГО1" => laborIntensity.GO1,
                                    "ГО2" => laborIntensity.GO2,
                                    "ГО1.1" => laborIntensity.GO11,
                                    "ГО1.2" => laborIntensity.GO12,
                                    _ => null,
                                };

                                logger.DefaultText($"[ст. {row}] - заказ {usedRange[row, setting[0]]}, марка {usedRange[row, setting[1]]}  ");

                                if (value.HasValue)
                                {
                                    logger.DefaultBoldText($"({usedRange[row, setting[2]]} = {value})\r\n");
                                }
                                else
                                {
                                    logger.ErrorText($"(Нет данных о группе [{usedRange[row, setting[2]]}]) \r\n");
                                }
                            }
                        }
                    }
                }

                logger.DefaultBoldText($"\r\nВыполнение завершено.\r\n");
            }
            catch (Exception ex)
            {
                logger.ExceptionText(ex);
            }
            finally
            {
                logger.Complete();
            }
        }
        public static void SetLaborIntensityOfProducts(LoggerForm logger)
        {
            try
            {
                logger.DefaultBoldText("Подготовка к работе.");
                var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                var usedRange = (object[,])worksheet.UsedRange.get_Value(Type.Missing);
                var settings = Properties.Settings.Default.LaborIntensityOfProductsSetting.Split().Select((x, i) => (Value: int.Parse(x), Group: i / 4))
                    .GroupBy(x => x.Group).Where(x => x.All(x => x.Value > 0)).Select(x => x.Select(y => y.Value).ToArray()).ToArray();
                if (settings.Length <= 0 || !settings.All(x => x.Max() < usedRange.GetLength(1)))
                {
                    logger.ErrorText(" ⚠ НАСТРОЙКИ НЕ КОРРЕКТНЫ\r\n");
                    return;
                }
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n\r\n");

                logger.DefaultBoldText($"Сбор данных:\r\n");
                var laborIntensityList = LoadLaborIntensityList(logger, Properties.Settings.Default.LIPMainDirectoryPath
                    , Properties.Settings.Default.LIPExcelFileName);
                logger.SuccessText($"Загружено {laborIntensityList.Count} записей\r\n\r\n");
                if (logger.IsClosed) return;

                logger.DefaultBoldText($"Заполнение таблицы:\r\n");
                int rowCount = usedRange.GetLength(0);
                for (int row = 1; row <= rowCount; row++)
                {
                    foreach (var setting in settings)
                    {
                        // 0 - заказ, 1 - марка, 2 - норма/часы, 3 - норма/чвсы (без сварки)
                        if (usedRange[row, setting[0]] != null && usedRange[row, setting[1]] != null)
                        {
                            var laborIntensity = laborIntensityList.FirstOrDefault(x => x.Order == usedRange[row, setting[0]].ToString()
                                && x.Mark == usedRange[row, setting[1]].ToString());
                            if (laborIntensity != null)
                            {
                                worksheet.Cells[row, setting[2]] = laborIntensity.HoursRate;
                                worksheet.Cells[row, setting[3]] = laborIntensity.HoursRateWithoutWelds;

                                logger.DefaultText($"[ст. {row}] - заказ {usedRange[row, setting[0]]}, марка {usedRange[row, setting[1]]}  ");
                                logger.DefaultBoldText($"(Н/ч = {laborIntensity.HoursRate}; Н/ч (без сварки) = {laborIntensity.HoursRateWithoutWelds}))\r\n");
                            }
                        }
                    }
                }

                logger.DefaultBoldText($"\r\nВыполнение завершено.\r\n");
            }
            catch (Exception ex)
            {
                logger.ExceptionText(ex);
            }
            finally
            {
                logger.Complete();
            }
        }

        private static List<string[][]> LoadExcelWorksheetLists(string excelFilePath, params int[] excelSheetIndexes)
        {
            var __sharedStringsRegex = new Regex("<si><t.*?>(.*?)</t></si>");
            var __cellValueRegex = new Regex("<v>(.*?)</v>");
            var __cellRowRegex = new Regex("\\d+");
            var __cellColRegex = new Regex("[A-Z]+");

            string[][] ParseWorksheets(string source, string[] sharedStrings)
            {
                string GetSharedString(int index)
                    => index >= sharedStrings.Length ? sharedStrings.Last() : sharedStrings[index];
                string GetCellValue(string source)
                    => source.IndexOf("t=\"s\"") > 0
                        ? GetSharedString(int.Parse(__cellValueRegex.Match(source).Groups[1].Value))
                        : __cellValueRegex.Match(source).Groups[1].Value;
                int GetCellRow(string source)
                    => int.Parse(__cellRowRegex.Match(source).Value);
                int GetCellCol(string source)
                    => __cellColRegex.Match(source).Value.Reverse().Select((x, i) => (x - 'A' + 1) * (int)Math.Pow(26, i)).Aggregate((x, y) => x + y);

                //body
                return source.Split(new string[] { "<c r=" }, StringSplitOptions.RemoveEmptyEntries).Skip(1)
                    .Select(x => (GetCellRow(x), GetCellCol(x), GetCellValue(x))).GroupBy(x => x.Item1)
                    .Select(x => Enumerable.Range(1, x.Max(y => y.Item2)).Select(y => x.FirstOrDefault(z => z.Item2 == y).Item3).ToArray()).ToArray();
            }

            //body
            Exception lastError = null;
            for (int tryCount = 0; tryCount < 3; tryCount++)
            {
                try
                {
                    using FileStream fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read);
                    using ZipArchive zipStream = new ZipArchive(fileStream, ZipArchiveMode.Read);

                    var sharedStrings = __sharedStringsRegex
                        .Matches(new StreamReader(zipStream.Entries.FirstOrDefault(x => x.FullName == "xl/sharedStrings.xml").Open()).ReadToEnd())
                        .Cast<Match>().ToArray().Select(x => x.Groups[1].Value).ToArray();

                    return zipStream.Entries.Where(x => x.FullName.Contains("xl/worksheets/sheet"))
                        .Select((x, i) => (Value: x, Index: int.Parse(x.Name.Substring(5, x.Name.IndexOf('.', 5) - 5))))
                        .Where(x => !(excelSheetIndexes.Length > 0 && !excelSheetIndexes.Contains(x.Index))).OrderBy(x => x.Index)
                        .Select(x => ParseWorksheets(new StreamReader(x.Value.Open()).ReadToEnd(), sharedStrings)).ToList();
                }
                catch (Exception ex)
                {
                    lastError = ex;
                }
            }
            throw lastError;
        }
        private static List<LaborIntensity> LoadLaborIntensityList(LoggerForm logger, string path, string name)
        {
            var taskContainerList = Directory.GetDirectories(path)
                .Select(x => x + "\\" + name).Where(x => File.Exists(x))
                .Select(x => (Task: new Task<LaborIntensity[]>(() => LoadExcelWorksheetLists(x, 1).First().Skip(8)
                     .Where(y => y.Length >= 27 && !string.IsNullOrWhiteSpace(y[0]))
                     .Select(x => new LaborIntensity(x)).ToArray()), Path: x)).ToList();

            taskContainerList.ForEach(x => x.Task.Start());
            var completed = new List<Task<LaborIntensity[]>>();

            do
            {
                foreach (var taskContainer in taskContainerList)
                {
                    if (!completed.Contains(taskContainer.Task))
                    {
                        switch (taskContainer.Task.Status)
                        {
                            case TaskStatus.RanToCompletion:
                                logger.DefaultText($"{taskContainer.Path} ");
                                logger.DefaultBoldText($"(Получено {taskContainer.Task.Result.Count()})\r\n");
                                completed.Add(taskContainer.Task);
                                break;
                            case TaskStatus.Faulted:
                                logger.DefaultText($"{taskContainer.Path}\r\n");
                                logger.ErrorText($"Ошибка: {taskContainer.Task.Exception.InnerException.Message}\r\n");
                                completed.Add(taskContainer.Task);
                                break;
                        }
                    }
                }
                Thread.Sleep(50);
                if (logger.IsClosed) return new List<LaborIntensity>();
            }
            while (!taskContainerList.All(x => x.Task.IsCompleted));

            return taskContainerList.Where(x => x.Task.Status == TaskStatus.RanToCompletion).SelectMany(x => x.Task.Result).ToList();
        }
    }
}
