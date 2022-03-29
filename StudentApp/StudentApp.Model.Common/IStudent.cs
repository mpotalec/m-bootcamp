using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Model.Common
{
    public interface IStudent
    {
        string PlaceOfResidence { get; set; }
        string SubjectOfStudent { get; set; }
        int Id { get; set; }
    }
}
