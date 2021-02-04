/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MDD4All.Notes.DataModels
{
    public class Notes
    {
        [XmlElement("Note")]
        [JsonProperty("notes")]
        public List<Note> NoteElements { get; set; } = new List<Note>();
    }
}
