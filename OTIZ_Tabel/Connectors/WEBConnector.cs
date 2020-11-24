using Microsoft.Office.Interop.Excel;
using OTIZ_Tabel.Connectors;
using OTIZ_Tabel.Types;
using OTIZ_Tabel.WebReference;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace OTIZ_Tabel
{
    internal class WebConnector : BaseConnector
    {
        public override ConnectorType ConnectorType => ConnectorType.WebConnector;


        public override void TestConnection(LoggerForm logger, string connectionString, string login, string password)
        {
            try
            {
                logger.DefaultBoldText("Тестовое подключение к базе 1С через WEB сервис.\r\n\r\n");
                logger.DefaultText("Инициализация сервиса запросов...");
                using Tabel tabel = new Tabel
                {
                    Url = connectionString,
                    SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12,
                    Credentials = new NetworkCredential(Utf8ToWin1251(login), Utf8ToWin1251(password))
                };
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                logger.DefaultText("Отправка тестового запроса...");
                tabel.GetTabel("", "20200101", "20200101");
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                logger.DefaultBoldText("\r\nТестирование успешно завершено!");
            }
            catch (Exception ex)
            {
                logger.ExceptionText(ex);
                ConnectionStatus = ConnectionStatus.Disconnected;
            }
            finally
            {
                logger.Complete();
            }
        }
        public override void SetWorkingHours(LoggerForm logger)
        {
            static string NormalizeCode(string source) => "-".PadLeft(5, '0') + source.PadLeft(5, '0');
            static string NormalizeCode2(string source) => "-".PadLeft(5, '0') + source.PadLeft(4, '0');

            try
            {
                logger.DefaultText("Проставление рабочих часов сотрудникам.\r\n\r\n");
                logger.DefaultText("Подключение к таблице EXCEL...");
                var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                logger.DefaultText("Инициализация сервиса запросов...");
                using Tabel tabel = new Tabel
                {
                    Url = Settings.WebConnectionString,
                    SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12,
                    Credentials = new NetworkCredential(Utf8ToWin1251(Settings.UserName), Utf8ToWin1251(Settings.UserPassword))
                };
                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");

                logger.DefaultText("Получение данных сотрудников...");
                logger.DefaultText("\r\nПроставление часов:\r\n");

                for (int row = Settings.FirstRow; row <= Settings.LastRow; row++)
                {
                    if (logger.IsClosed) return;
                    string code = Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value);
                    if (code.IsInt())
                    {
                        code = NormalizeCode(code);
                        var employe = ParseEmploye(tabel.GetTabel(code, Settings.FirstDate.ToSolidDate(), Settings.LastDate.ToSolidDate()));
                        if (employe == null)
                        {
                            code = NormalizeCode2(Convert.ToString(worksheet.Cells[row, Settings.CodeCol].Value));
                            employe = ParseEmploye(tabel.GetTabel(code, Settings.FirstDate.ToSolidDate(), Settings.LastDate.ToSolidDate()));
                        }

                        logger.DefaultText($"{row} стр.  [{code}]");
                        if (employe != null)
                        {
                            string name = Convert.ToString(worksheet.Cells[row, Settings.FioCol].Value);
                            if (employe.FIO.ToLower() == name.Trim().ToLower())
                            {
                                logger.DefaultText($" {employe.FIO}");
                                worksheet.Cells[row, Settings.NormalCol] = employe.Normal + employe.Night + employe.Holiday;
                                worksheet.Cells[row, Settings.NightCol] = employe.Night;
                                worksheet.Cells[row, Settings.HolidayCol] = employe.Holiday;
                                logger.SuccessText(" ✓ ВЫПОЛНЕНО\r\n");
                            }
                            else
                            {
                                logger.DefaultText($" {employe.FIO} != {name}");
                                logger.ErrorText($" ⚠ НЕСООТВЕТСТВИЕ ДАННЫХ\r\n");
                                worksheet.Cells[row, Settings.NormalCol] = 0;
                                worksheet.Cells[row, Settings.NightCol] = 0;
                                worksheet.Cells[row, Settings.HolidayCol] = 0;
                            }
                        }
                        else
                        {
                            logger.ErrorText($" ⚠ НЕТ ИНФОРМАЦИИ\r\n");
                            worksheet.Cells[row, Settings.NormalCol] = 0;
                            worksheet.Cells[row, Settings.NightCol] = 0;
                            worksheet.Cells[row, Settings.HolidayCol] = 0;
                        }
                    }
                    else
                    {
                        logger.DefaultText($"{row} стр.  [{code}] - ");
                        logger.GrayText(" ПРОПУЩЕНО\r\n");
                    }
                }

                logger.DefaultText("\r\nВыполнение программы завершено!");
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
                    if (count > 3) employe.Normal = GetValue(strings[30], 1).ToInt();
                    if (count > 4) employe.Night = GetValue(strings[31], 1).ToInt();
                    if (count > 5) employe.Holiday = GetValue(strings[32], 1).ToInt();
                }
            }
            catch
            {
                throw new Exception("Не верная структура полученных данных.");
            }
            return employe;
        }
        private string Utf8ToWin1251(string source)
        {
            var win1251 = Encoding.GetEncoding("windows-1251");
            var utf8 = Encoding.GetEncoding("utf-8");
            return utf8.GetString(Encoding.Convert(win1251, utf8, utf8.GetBytes(source)));
        }
    }
}
