using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business.Model
{
    public class Quote
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _sentence;
        public string Sentence
        {
            get => _sentence;
            set => _sentence = value;
        }

        private string _author;
        public string Author
        {
            get => _author;
            set => _author = value;
        }
    }
}
