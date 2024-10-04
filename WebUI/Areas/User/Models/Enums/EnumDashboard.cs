

using System.ComponentModel;

namespace WebUI.Core.Enum
{
    /// <summary></summary>
    public enum EnumDashboardCartableType
    {
        [Description("سند")]
        Document = 1,
        [Description("فرم")]
        DocumentForm = 2,
        [Description("درخواست سند")]
        DocumentRequest = 3,
        [Description("درخواست فرم")]
        DocumentFormRequest = 4,
    }
}
