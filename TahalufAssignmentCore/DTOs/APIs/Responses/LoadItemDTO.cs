using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahalufAssignmentCore.DTOs.APIs.Responses
{
    public class LoadItemDTO<T>
    {
        public List<T> Items { get; set; }
        public int TotalItem { get; set; }
    }
}
