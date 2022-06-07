using Abstractions;
using Model;
using System.Xml.Serialization;

namespace Implementations.DataProviders
{
    public class XMLDataProvider : IDataProvider
    {

        private readonly string _FileFullPath = "";

        public XMLDataProvider(string aFileFullPath)
        {
            if (!File.Exists(aFileFullPath)) throw new FileNotFoundException(aFileFullPath);
            _FileFullPath = aFileFullPath;
        }


        /// <summary>
        /// Devuelve la lista de los Tests
        /// </summary>
        /// <param name="aFileFullPath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public ExerciseInput GetExerciseInput()
        {
            ExerciseInput? iRetVal = null;

            Type iTargetType = typeof(ExerciseInput);
            XmlSerializer iSerializer = new(iTargetType);
            using (StreamReader iSr = new(_FileFullPath))
            {
                 iRetVal = (ExerciseInput)iSerializer.Deserialize(iSr) ?? 
                    throw new Exception($"No se pudo deserializar el contenido del fichero '{_FileFullPath}' en el tipo '{iTargetType.FullName}'");
            }
            return iRetVal;
        }
    }
}
