﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesMoshCourse
{
    public class Stack<T>
    {
        private readonly List<T> _list = new List<T>();

        public int count => _list.Count;

        public void Push(T obj)
        {
            if (obj is null)
                throw new ArgumentNullException();
            
            _list.Add(obj);
        }

        public T Pop()
        {
            if(_list.Count == 0)
                throw new InvalidOperationException();

            var result = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count -1);

            return result;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            return _list[_list.Count - 1];
        }
    }
}
