using System;

namespace task1 {
    public class Client
    {
        public string Name { get; }

        public Client(string name)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }
    }
}