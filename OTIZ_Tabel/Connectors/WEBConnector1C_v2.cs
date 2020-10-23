using Microsoft.Office.Interop.Excel;
using OTIZ_Tabel.WebReference;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;

namespace OTIZ_Tabel
{
    class WEBConnector1C_v2 : IConnector1C
    {
        private Tabel _tabel;

        public ConnectionStatusType ConnectionStatus { get; private set; }
        public void Connection(LoggerForm logger, ConnectData conDate)
        {
            ConnectionStatus = ConnectionStatusType.Progress;
            try
            {
                logger.LogText("Подключение к базе 1С через WEB сервис.\r\n\r\n", Color.Black, FontStyle.Bold);

                logger.LogText("Инициализация сервиса запросов...", Color.Black, FontStyle.Regular);
                _tabel = new Tabel
                {
                    Url = conDate.WEBLink,
                    SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12,
                   Credentials = new NetworkCredential(Utf8ToWin1251(conDate.UserName), Utf8ToWin1251(conDate.UserPassword))
                 //   Credentials = new NetworkCredential(Utf8ToWin1251(conDate.UserName), conDate.UserPassword)
                };
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("Отправка тестового запроса...", Color.Black, FontStyle.Regular);
                _tabel.GetTabel("", "20200101", "20200101");
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("\r\nПодключение успешно завершено!", Color.Black, FontStyle.Regular);
                ConnectionStatus = ConnectionStatusType.Connected;
            }
            catch (Exception ex)
            {
                logger.LogText(" ❌ ОШИБКА\r\n", Color.Red, FontStyle.Bold);
                logger.LogText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n", Color.Black, FontStyle.Regular);
                ConnectionStatus = ConnectionStatusType.Disconnected;
            }
            finally
            {
                logger.Complete();
            }
        }
        public void Disonnection()
        {
            _tabel?.Dispose();
            ConnectionStatus = ConnectionStatusType.Disconnected;
        }
        public void SetWorkingHours(LoggerForm logger)
        {
            static string NormalizeCode(string source) 
                => "-".PadLeft(5, '0') + source.PadLeft(5, '0');
            static string NormalizeCode2(string source) 
                => "-".PadLeft(5, '0') + source.PadLeft(4, '0');

            var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;


           // Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value);

            //try
            //{
            //    logger.LogText("Проставление рабочих часов сотрудникам.\r\n\r\n", Color.Black, FontStyle.Bold);

            //    logger.LogText("Подключение к таблице EXCEL...", Color.Black, FontStyle.Regular);
            //    var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            //    logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

            //    logger.LogText("Получение данных сотрудников...", Color.Black, FontStyle.Regular);

            //    logger.LogText("\r\nПроставление часов:\r\n", Color.Black, FontStyle.Regular);
            //    for (int row = Settings.FirstRow; row <= Settings.LastRow; row++)
            //    {
            //        if (logger.IsClosed) return;
            //        string codeVal = Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value);
            //        if (codeVal.IsInt())
            //        {
            //            codeVal = NormalizeCode(codeVal);
            //            var employe = ParseEmploye(_tabel.GetTabel(codeVal, Settings.FirstDate.To_1CDate(), Settings.LastDate.To_1CDate()));
            //            if (employe == null)
            //            {
            //                codeVal = NormalizeCode2(Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value));
            //                employe = ParseEmploye(_tabel.GetTabel(codeVal, Settings.FirstDate.To_1CDate(), Settings.LastDate.To_1CDate()));
            //            }

            //            logger.LogText($"{row} стр.  [{codeVal}]", Color.Black, FontStyle.Regular);
            //            if (employe != null)
            //            {
            //                string name = Convert.ToString(worksheet.Cells[row, Settings.FIOCol].Value);
            //                if (employe.FIO.ToLower() == name.Trim().ToLower())
            //                {
            //                    logger.LogText($" {employe.FIO}", Color.Black, FontStyle.Regular);
            //                    worksheet.Cells[row, Settings.AppearCol] = employe.Appear + employe.Night + employe.Feast;
            //                    worksheet.Cells[row, Settings.NightCol] = employe.Night;
            //                    worksheet.Cells[row, Settings.FeastCol] = employe.Feast;
            //                    logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);
            //                }
            //                else
            //                {
            //                    logger.LogText($" {employe.FIO} != {name}", Color.Black, FontStyle.Regular);
            //                    logger.LogText($" ⚠ НЕСООТВЕТСТВИЕ ДАННЫХ\r\n", Color.Red, FontStyle.Bold);
            //                    worksheet.Cells[row, Settings.AppearCol] = 0;
            //                    worksheet.Cells[row, Settings.NightCol] = 0;
            //                    worksheet.Cells[row, Settings.FeastCol] = 0;
            //                }
            //            }
            //            else
            //            {
            //                logger.LogText($" ⚠ НЕТ ИНФОРМАЦИИ\r\n", Color.Red, FontStyle.Bold);
            //                worksheet.Cells[row, Settings.AppearCol] = 0;
            //                worksheet.Cells[row, Settings.NightCol] = 0;
            //                worksheet.Cells[row, Settings.FeastCol] = 0;
            //            }
            //        }
            //        else
            //        {
            //            logger.LogText($"{row} стр.  [{codeVal}] - ", Color.Black, FontStyle.Regular);
            //            logger.LogText(" ПРОПУЩЕНО\r\n", Color.Gray, FontStyle.Bold);
            //        }
            //    }

            //    logger.LogText("\r\nВыполнение программы завершено!", Color.Black, FontStyle.Regular);
            //}
            //catch (Exception ex)
            //{
            //    logger.LogText(" ❌ ОШИБКА\r\n", Color.Red, FontStyle.Bold);
            //    logger.LogText($"\r\nСообщение об ошибке:\r\n{ex.Message}\r\n", Color.Black, FontStyle.Regular);
            //}
            //finally
            //{
            //    logger.Complete();
            //}
        }
        public void TestConnection(LoggerForm logger, ConnectData conDate)
        {
            try
            {
                logger.LogText("Тестовое подключение к базе 1С через WEB сервис.\r\n\r\n", Color.Black, FontStyle.Bold);

                logger.LogText("Инициализация сервиса запросов...", Color.Black, FontStyle.Regular);
                using Tabel tabel = new Tabel
                {
                    Url = conDate.WEBLink,
                    SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12,
                    Credentials = new NetworkCredential(Utf8ToWin1251(conDate.UserName), Utf8ToWin1251(conDate.UserPassword))
                };
                logger.LogText(" ✓ ВЫПОЛНЕНО\r\n", Color.Green, FontStyle.Bold);

                logger.LogText("Отправка тестового запроса...", Color.Black, FontStyle.Regular);
                tabel.GetTabel("", "20200101", "20200101");
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

        private string Utf8ToWin1251(string source)
        {
            return Encoding.GetEncoding("windows-1251").GetString(Encoding.UTF8.GetBytes(source));
        }
        private Employe ParseEmploye(string source)
        {
            static string GetValue(string source, int num)
                => source.Trim(new char[] { '{', '}', ',', '"' }).Split(',').ToList()[num].Trim('{', '}', '"', ' ');

            Employe employe = null;
            var strings = source.Split(new char[] { '\r', '\n' });
            try
            {
                int count = GetValue(strings[26], 2).ToInt();
                if (count > 0)
                {
                    employe = new Employe
                    {
                        FIO = GetValue(strings[28], 1),
                        Code = GetValue(strings[29], 1),
                    };
                    if (count > 3) employe.Appear = GetValue(strings[30], 1).ToInt();
                    if (count > 4) employe.Night = GetValue(strings[31], 1).ToInt();
                    if (count > 5) employe.Feast = GetValue(strings[32], 1).ToInt();
                }
            }
            catch
            {
                throw new Exception("Не верная структура полученных данных.");
            }
            return employe;
        }
    }
}
