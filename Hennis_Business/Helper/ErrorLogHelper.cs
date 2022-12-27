using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Helper
{
    public class ErrorLogHelper
    {
        private readonly ApplicationDbContext _context;

        public ErrorLogHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public static void LogError(ApplicationDbContext context, Exception ex, string title)
        {
            var error = new ErrorLog
            {
                Message = ex?.Message,
                StackTrace = ex.StackTrace,
                Title = title
            };

            context.ErrorLogs.Add(error);
            context.SaveChanges();
        }
    }
}
