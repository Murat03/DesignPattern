﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("CANON");
            Camera camera4 = Camera.GetCamera("CANON");
            Camera camera2 = Camera.GetCamera("NIKON");
            Camera camera3 = Camera.GetCamera("NIKON");
            Camera camera5 = Camera.GetCamera("NIKON");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera4.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera5.Id);
            

            Console.ReadLine();
        }
    }
    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }
        public Camera()
        {
            Id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if(!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand,new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
