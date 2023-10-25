using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class MeetingLoader
    {
        private dynamic data;

        public void Load(dynamic data)
        {
            this.data = new
            {
                date = data.date,
                description = data.description,
                url = data.url,
                participants = data.participants,
            };
        }

        public dynamic GetData()
        {
            return data;
        }
        public override string ToString()
        {
            return $"Meeting Date: {data.date}, Description: {data.description}, URL: {data.url}";
        }
    }
}
