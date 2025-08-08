using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace NoteWriter.Logic
{
    public class NoteObject
    {
        public string path { get; set; } = "";
        public string title { get; set; } = "";
        public string text { get; set; } = "";
        public long size { get; set; } = -1;
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public NoteObject() { }
        public NoteObject(string path, string title, string text, long size, DateTime created, DateTime modified)
        {
            this.path = path;
            this.title = title;
            this.text = text;
            this.size = size;
            this.created = created;
            this.modified = modified;
        }
        public void JsonToNote(string json)
        {
            try
            {
                var noteData = JsonSerializer.Deserialize<NoteObject>(json);
                if (noteData != null)
                {
                    title = noteData.title;
                    text = noteData.text;
                    path = noteData.path;
                    size = noteData.size;
                    created = noteData.created;
                    modified = noteData.modified;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON to Note: {ex.Message}");
            }
        }
        public JsonObject ToJson()
        {
            try
            {
                return JsonSerializer.SerializeToNode(this) as JsonObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON to Note: {ex.Message}");
                return null;
            }
        }
    }
}