using Microsoft.AspNetCore.Mvc;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.Controllers
{
    public class InstituteController : ControllerBase
    {
        private UnitOfWork<TimeasyDbContext> unitOfWork = new UnitOfWork<TimeasyDbContext>();


        public InstituteController() { 
            
        }
    }
}
