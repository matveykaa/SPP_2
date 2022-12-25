using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.DTO
{
    public class Picture
    {
        public int pictureId { get; set; }

        public int CCC;   
        public string url { get; set; }
        public DateTime addedDate { get; set; }
        public Collection collection { get; set; }
        public Administrator administrator { get; set; }
        public Picture()
        {
            pictureId = 39;
        }
    }
}
