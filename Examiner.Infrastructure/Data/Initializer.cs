using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Data
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ExaminerDBContext>
    {
        protected override void Seed(ExaminerDBContext context)
        {
            InitializeUser(context);
            InitializeData(context);
            base.Seed(context);
        }

        private void InitializeUser(ExaminerDBContext context)
        {

        }

        private void InitializeData(ExaminerDBContext context)
        {

        }
    }
}
