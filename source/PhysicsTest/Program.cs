﻿using System;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Collections.Generic;

using Cheetah;
using Cheetah.Graphics;

using OpenTK;

using Cheetah.Physics;

namespace PhysicsTest
{
    class Cube : PhysicsNode
    {
        public Cube()
        {
            Draw = new System.Collections.ArrayList();
            Draw.Add(Root.Instance.ResourceManager.LoadMesh("cube/cube.mesh"));
        }

        protected override IPhysicsObject CreatePhysicsObject(Scene s)
        {
            return s.Physics.CreateObjectBox(1, 2, 2, 2);
        }
    }

    class Floor : PhysicsNode
    {
        public Floor()
        {
            Draw = new System.Collections.ArrayList();
            Draw.Add(Root.Instance.ResourceManager.LoadMesh("floor/floor.mesh"));
        }

        protected override IPhysicsObject CreatePhysicsObject(Scene s)
        {
            IPhysicsObject obj=s.Physics.CreateObjectBox(1, 200, 2, 200);
            obj.Movable = false;
            return obj;
        }
    }

    class PhysicsFlow : Flow
    {
        public PhysicsFlow()
        {
        }

        public override void Start()
        {
            base.Start();

            Root.Instance.Scene = new Scene();

            camera = new Camera();
            camera.Position = new Vector3(20, 20, 20);
            camera.LookAt(0, 5, 0);

            for (int i = 0; i < 10; ++i)
            {
                Cube c = new Cube();
                Root.Instance.Scene.Spawn(c);
                c.Position = new Vector3(0, 10 + i * 2, 0);
                cubes.Add(c);
            }
            Root.Instance.Scene.Spawn(new Floor());

            Root.Instance.Scene.camera = camera;
            Root.Instance.Scene.Spawn(light = new Light());
            light.Position = new Vector3(1, 1, 1);
            light.directional = true;
        }

        public override void Tick(float dtime)
        {
            base.Tick(dtime);

            camera.LookAt(cubes[cubes.Count - 1].Position);
        }

        List<Cube> cubes = new List<Cube>();
        Camera camera;
        Light light;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");

            string dir = Directory.GetCurrentDirectory();
            Assembly a = Assembly.GetEntryAssembly();
            System.Console.WriteLine("assembly path:" + a.Location);

            int i = Array.IndexOf<string>(args, "-root");
            if (i != -1)
            {
                string rootdir = args[i + 1];
                Directory.SetCurrentDirectory(rootdir);
                System.Console.WriteLine("root directory: " + rootdir);
            }
            else
            {
                DirectoryInfo current = new FileInfo(a.Location).Directory;
                while (current.GetFiles("cheetah_root").Length == 0)
                {
                    if ((current = current.Parent) == null)
                    {
                        throw new Exception("Can't find game root directory. Use -root $directory.");
                    }
                }
                Directory.SetCurrentDirectory(current.FullName);
                System.Console.WriteLine("root directory: " + current.FullName);
            }

            Root r = new Root(args, false);
            r.ClientClient(args);
            IUserInterface ui = r.UserInterface;

            Flow f = new PhysicsFlow();

            r.CurrentFlow = f;

            f.Start();

            r.ClientLoop();

            r.Dispose();
        }
    }
}