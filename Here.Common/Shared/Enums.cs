using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Here.Common.Shared
{
  public enum EventTypes
  {
    [Description("Entrada")]
    ENTRADA = 1,
    [Description("Salida")]
    SALIDA = 2,
    [Description("Asistencia")]
    ASISTENCIA = 3,
    [Description("Falta")]
    FALTA = 4,
    [Description("Retardo")]
    RETARDO = 5,
    [Description("Incapacidad")]
    INCAPACIDAD = 6,
    [Description("Permiso Interno")]
    PERMISO_INTERNO = 7,
    [Description("Vacaciones")]
    VACACIONES = 8
  }

  public enum Roles
  {
    [Description("Overwatch")]
    OVERWATCH = 1,
    [Description("Administrator")]
    ADMINISTRATOR = 2,
    [Description("Owner")]
    COMPANY_OWNER = 3,
    [Description("Assist Tracker")]
    ASSIST_TRACKER = 4
  }
}
