using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using V83;

namespace OTIZ_Tabel
{
    internal class COMConnector1C : IConnector
    {
        private Properties.Settings _settings = Properties.Settings.Default;
        private readonly List<Employe> _employes = new List<Employe>();
        private COMConnector _connector;
        private dynamic _connection;

        public ConnectionStatusType ConnectionStatus { get; private set; }
        public void Connection(LoggerForm logger)
        {
            //$"{ConnectString}Usr=\"{UserName}\";Pwd =\"{UserPassword}\""
            ConnectionStatus = ConnectionStatusType.Progress;
            try
            {
                logger.LogText("Подключение к базе 1С через COM порт.\r\n\r\n", Color.Black, FontStyle.Bold);

                logger.LogText("Инициализация компонента ActiveX \"V83.COMConnector\"...", Color.Black, FontStyle.Regular);
                _connector = new COMConnector();
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("Установка соединения с 1С...", Color.Black, FontStyle.Regular);
                _connection = _connector.Connect($"{_settings.ComConnectionString}Usr=\"{_settings.UserName}\";Pwd =\"{_settings.UserPassword}\"");
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                if (Properties.Settings.Default.Preload) LoadEmployes(logger, true);

                logger.Complete();
                ConnectionStatus = ConnectionStatusType.Connected;

                logger.LogText("\r\nПодключение успешно завершено!", Color.Black, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                logger.LogText(" ❌ ОШИБКА\r\n", Color.Red, FontStyle.Bold);
                logger.LogText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n", Color.Black, FontStyle.Regular);
                logger.Complete();
                ConnectionStatus = ConnectionStatusType.Disconnected;
            }
        }
        public void Disonnection()
        {
            Marshal.ReleaseComObject(_connector);
            ConnectionStatus = ConnectionStatusType.Disconnected;
        }
        public void SetWorkingHours(LoggerForm logger)
        {

            static string NormalizeCode(string source)
                => "-".PadLeft(5, '0') + source.PadLeft(5, '0');
            static string NormalizeCode2(string source)
                => "-".PadLeft(5, '0') + source.PadLeft(4, '0');


            try
            {
                logger.LogText("Проставление рабочих часов сотрудникам.\r\n\r\n", Color.Black, FontStyle.Bold);

                logger.LogText("Подключение к таблице EXCEL...", Color.Black, FontStyle.Regular);
                var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                if (!_settings.Preload) LoadEmployes(logger);

                logger.LogText("\r\nПроставление часов:\r\n", Color.Black, FontStyle.Regular);
                for (int row = _settings.FirstRow; row <= _settings.LastRow; row++)
                {
                    if (logger.IsClosed) return;
                    string codeVal = Convert.ToString(worksheet.Cells[row, _settings.CodeCol].Value);
                    if (codeVal.IsInt())
                    {
                        codeVal = NormalizeCode(codeVal);
                        var employe = _employes.Where(x => x.Code == codeVal).FirstOrDefault();
                        if (employe == null)
                        {
                            codeVal = NormalizeCode2(Convert.ToString(worksheet.Cells[row, _settings.CodeCol].Value));
                            employe = _employes.Where(x => x.Code == codeVal).FirstOrDefault();
                        }

                        logger.LogText($"{row} стр.  [{codeVal}]", Color.Black, FontStyle.Regular);
                        if (employe != null)
                        {
                            string name = Convert.ToString(worksheet.Cells[row, _settings.FIOCol].Value);
                            if (employe.FIO.ToLower() == name.ToLower())
                            {
                                logger.LogText($" {employe.FIO}", Color.Black, FontStyle.Regular);
                                foreach (dynamic record in (IEnumerable)_connection.ТСМ.ПолучитьВремя(_settings.FirstDate, _settings.LastDate, employe.Data))
                                {
                                    employe.Appear += record.Явки;
                                    employe.Night += record.Ночные;
                                    employe.Feast += record.Праздники;
                                }
                                worksheet.Cells[row, _settings.AppearCol] = employe.Appear + employe.Night + employe.Feast;
                                worksheet.Cells[row, _settings.NightCol] = employe.Night;
                                worksheet.Cells[row, _settings.FeastCol] = employe.Feast;
                                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);
                            }
                            else
                            {
                                logger.LogText($" {employe.FIO} != {name}", Color.Black, FontStyle.Regular);
                                logger.LogText($" ⚠ НЕСООТВЕТСТВИЕ ДАННЫХ\r\n", Color.Red, FontStyle.Bold);
                                worksheet.Cells[row, _settings.AppearCol] = 0;
                                worksheet.Cells[row, _settings.NightCol] = 0;
                                worksheet.Cells[row, _settings.FeastCol] = 0;
                            }
                        }
                        else
                        {
                            logger.LogText($" ⚠ НЕТ ИНФОРМАЦИИ\r\n", Color.Red, FontStyle.Bold);
                            worksheet.Cells[row, _settings.AppearCol] = 0;
                            worksheet.Cells[row, _settings.NightCol] = 0;
                            worksheet.Cells[row, _settings.FeastCol] = 0;
                        }
                    }
                    else
                    {
                        logger.LogText($"{row} стр.  [{codeVal}] - ", Color.Black, FontStyle.Regular);
                        logger.LogText(" ПРОПУЩЕНО\r\n", Color.Gray, FontStyle.Bold);
                    }
                }
                logger.LogText("\r\nВыполнение программы завершено!", Color.Black, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                logger.LogText(" ❌ ОШИБКА\r\n", Color.Red, FontStyle.Bold);
                logger.LogText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n", Color.Black, FontStyle.Regular);
            }
            finally
            {
                logger.Complete();
            }
        }
        public void TestConnection(LoggerForm logger)
        {
            //тестирование соединения происходит с использованием библиотек VisualBasic
            //это необходимо для получения человекочитаемых сообщений при исключениях.
            try
            {
                logger.LogText("Тестовое подключение к базе 1С через COM порт.\r\n\r\n", Color.Black, FontStyle.Bold);

                logger.LogText("Инициализация компонента ActiveX \"V83.COMConnector\"...", Color.Black, FontStyle.Regular);
                object COMConnector = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("V83.COMConnector"));
                if (logger.IsClosed) return;
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("Установка соединения с 1С...", Color.Black, FontStyle.Regular);
                object COMConnection = RuntimeHelpers.GetObjectValue(
                    NewLateBinding.LateGet(COMConnector, null, "Connect", 
                    new object[1] { $"{_settings.ComConnectionString}Usr=\"{_settings.UserName}\";Pwd =\"{_settings.UserPassword}\"" }, null, null, null));
                if (logger.IsClosed) return;
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("\r\nТестирование успешно завершено!", Color.Black, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                logger.LogText(" ❌ ОШИБКА\r\n", Color.Red, FontStyle.Bold);
                logger.LogText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n", Color.Black, FontStyle.Regular);
            }
            finally
            {
                logger.Complete();
            }
        }

        private void LoadEmployes(LoggerForm logger, bool fullTime = false)
        {
            logger.LogText("Получение списка сотрудников...", Color.Black, FontStyle.Regular);
            dynamic getEmploye = fullTime
                ? _connection.ТСМ.ПолучитьСписокСотрудников(new DateTime(2010, 1, 1), DateTime.Now)
                : _connection.ТСМ.ПолучитьСписокСотрудников(Properties.Settings.Default.FirstDate, Properties.Settings.Default.LastDate);


            _employes.Clear();
            while (getEmploye.Следующий())
            {
                _employes.Add(new Employe { Data = getEmploye.Сотрудник, FIO = getEmploye.Сотрудник.Наименование, Code = getEmploye.СотрудникКод });
                if (logger.IsClosed) return;
            }

            logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);
        }
    }
}
