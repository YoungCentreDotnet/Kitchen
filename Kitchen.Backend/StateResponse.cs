﻿using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace Kitchen.Backend
{
    public class StateResponse<T>
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
