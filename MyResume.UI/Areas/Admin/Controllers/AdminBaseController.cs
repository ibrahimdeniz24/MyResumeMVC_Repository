using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyResume.UI.Controllers;

namespace MyResume.UI.Areas.Admin.Controllers
{
    //bu controllerın admin oludugun belirmtek için yapıyoruz. Fakat
    [Area("Admin")]
    //Role kontrolu yapıyoruz. Admin role sahip değilse giremez.
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : BaseController
    {
    }
}
