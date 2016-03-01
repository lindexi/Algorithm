using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Algorithm.ViewModel
{
    public class viewModel:notify_property
    {
        public viewModel()
        {
            _model_common_divisor=new common_divisor();
            int m = 60;
            int n = 24;
            reminder = _model_common_divisor.euler(m, n).ToString();
        }

        Model.common_divisor _model_common_divisor;
    }
}
