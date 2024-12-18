
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using System.Drawing;
    using Newtonsoft.Json;

    namespace LabWo3
    {
        public static class FileManagement
        {
            const string file_name = "BoardGame";

            public static GameState Deserialize_Game(string json)
            {

                return JsonConvert.DeserializeObject<GameState>(json); ;
            }

            public static string Save_to_file(GameState model)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(file_name, json);
                }
                catch (IOException ex)
                {
                    return $"Ошибка записи в файл: {ex.Message}";

                }
                catch (Exception ex)
                {
                    return $"Непредвиденная ошибка: {ex.Message}";
                }
                return "";
            }

            public static GameState Get_from_file()
            {

                try
                {
                    if (!File.Exists(file_name))
                    {
                        throw new FileNotFoundException();
                    }
                    string json = File.ReadAllText(file_name);

                    return Deserialize_Game(json);
                }
                catch
                {

                    return null;
                }
            }

            public static void Clear_File()
            {
                File.Delete(file_name);
            }
        }
    }
