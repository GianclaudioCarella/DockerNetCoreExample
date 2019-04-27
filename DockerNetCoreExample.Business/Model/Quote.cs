using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business.Model
{
    public class Quote
    {
        private string _sentence;
        public string Sentence
        {
            get => _sentence;
            set => value?.ToString();
        }

        private string _author;
        public string Author
        {
            get => _author;
            set => value?.ToString();
        }
    }
}
