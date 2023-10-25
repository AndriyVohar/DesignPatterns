using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class UserLoader
    {
        private dynamic data;

        public void Load(dynamic data)
        {
            this.data = new
            {
                id = data.id,
                name = data.name,
                avatar = data.avatar,
            };
        }

        public dynamic GetData()
        {
            return data;
        }
        public override string ToString()
        {
            return $"User ID: {data.id}, Name: {data.name}, Avatar: {data.avatar}";
        }
    }
}
