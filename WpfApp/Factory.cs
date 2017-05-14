using System;
using WpfApp.Model;

namespace WpfApp
{
    public class Factory 
    {
        public IDetail Create<T>(string param)
        {
            Type type;
            switch (param)
            {
                case "Door":
                    type = typeof(Door);
                    break;
                case "Wheel":
                    type = typeof(Wheel);
                    break;
                case "Nut":
                    type = typeof(Nut);
                    break;
                default:
                    return null;
            }
            type = type.MakeGenericType(typeof(T));
            return (IDetail)Activator.CreateInstance(type);
        }

    }
}
