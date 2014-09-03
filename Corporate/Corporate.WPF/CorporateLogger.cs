using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Unity;

using Corporate.Domain;
using Corporate.Domain.Entities;
using Corporate.Interfaces.Repositories;
using Corporate.Service.Repositories;

namespace Corporate.WPF
{
    public class CorporateLogger : ILoggerFacade
    {
        public IExceptionLogRepository _exceptionRepository;

        public CorporateLogger()
        {
            _exceptionRepository = new ExceptionRepository(new CorporateContext());
        }

        public CorporateLogger(IUnityContainer container)
        {
            _exceptionRepository = container.Resolve<IExceptionLogRepository>();//repository;
        }

        public void Log(string message, Category category, Priority priority)
        {
            var log = new ExceptionLog
            {
                ExceptionDate = DateTime.Now,
                Details = message + " : " + category.GetType() + " : " + priority.GetType(),
                Message = message
            };
            _exceptionRepository.SaveLog(log);
        }
    }
}
