using NoteWriter.Logic;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Text.Json;


namespace NoteWriter.Logic
{
    internal class NoteLogic : NoteObject
    {
        protected NoteObject note { get; set; }
        public NoteLogic() { }
        FileEdit fileEdit;
        public NoteObject CreateNoteObject(string setPath, string setTitle, string setText)
        {
            try
            {
                note = new NoteObject();
                note.title = setTitle;
                note.text = setText;
                note.created = DateTime.Now;
                //note.extension = setExtension;
                return this;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool SaveNote(NoteObject note, string path)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string targetDirectory = Path.Combine(basePath, path);
                string filePath = Path.Combine(targetDirectory, note.title + ".txt");

                fileEdit = new FileEdit();

                if (!Directory.Exists(note.path))
                {
                    Directory.CreateDirectory(note.path);
                }
                fileEdit.Write(filePath, note.ToJson().ToString(), false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving note: {ex.Message}");
                return false;
            }
        }
        public NoteObject GetNote(string path)
        {
            try
            {
                string dataFromFile = File.ReadAllText(path);

                //var lines = dataFromFile.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                //note.title = lines.FirstOrDefault(l => l.StartsWith("Title:"))?.Replace("Title:","").Trim();
                //note. = lines.FirstOrDefault(l => l.StartsWith("Date:"))?.Replace("Date:","").Trim();
                //note.text = lines.FirstOrDefault(l => l.StartsWith("Text:"))?.Replace("Text:","").Trim();
                //note.path = path;
                note = JsonSerializer.Deserialize<NoteObject>(dataFromFile, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return note;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading note: {ex.Message}");
                return null;
            }
        }
        public List<NoteObject> GetAllNotes(string path)
        {
            List<NoteObject> notes = new List<NoteObject>();
            try
            {
                //string basePath = FileSystem.AppDataDirectory;
                //if (Directory.Exists(directory))
                //{
                //    var files = Directory.GetFiles(directory, "*.txt");
                //    foreach (var file in files)
                //    {
                //        var note = GetNote(file);
                //        if (note != null)
                //        {
                //            notes.Add(note);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving notes: {ex.Message}");
            }
            return notes;
        }
    }
}
