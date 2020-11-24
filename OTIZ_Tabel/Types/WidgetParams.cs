using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTIZ_Tabel.Types
{
    public enum WidgetParams
    {
        None        = 0b000000000000000,
        UseWidget   = 0b000000000000001,
        ShowLast    = 0b000000000000010,
        ShowFirst   = 0b000000000000100,
        ShowFIO     = 0b000000000001000,
        ShowCode    = 0b000000000010000,
        ShowHoliday = 0b000000000100000,
        ShowNight   = 0b000000001000000,
        ShowNormal  = 0b000000010000000,
    }
}
