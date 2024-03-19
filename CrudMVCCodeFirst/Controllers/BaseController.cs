using CrudMVCCodeFirst.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCCodeFirst.Controllers
{
    /// <summary>
    /// Controllers that require permission verification inherit this class
    /// </summary>
    [AuthorizeFilter]
    public class BaseController : Controller
    {

    }
}