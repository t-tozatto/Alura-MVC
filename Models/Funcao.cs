using System.Linq;

namespace Alura_MVC.Models
{
    public static class Funcao
    {
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (sourceProp.Name.Equals("Id"))
                {
                    if (destProps.Any(x => x.Name == sourceProp.Name))
                    {
                        var p = destProps.FirstOrDefault(x => x.Name == sourceProp.Name);
                        if (p != null)
                        { // check if the property can be set or no.
                            p.SetValue(dest, sourceProp.GetValue(source, null), null);
                        }
                    }
                }
            }

        }
    }
}
