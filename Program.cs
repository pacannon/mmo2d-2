﻿using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
 
namespace mmo2d_2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    // setup settings, load textures, sounds
                    game.VSync = VSyncMode.On;
                };
 
                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };
 
                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                };
 
                game.RenderFrame += (sender, e) =>
                {
                    // render graphics
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
 
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
 
                    GL.Begin(PrimitiveType.Triangles);
 
                    GL.Color3(OpenTK.Color.MidnightBlue);
                    GL.Vertex2(-1.0f, 1.0f);
                    GL.Color3(OpenTK.Color.SpringGreen);
                    GL.Vertex2(0.0f, -1.0f);
                    GL.Color3(OpenTK.Color.Ivory);
                    GL.Vertex2(1.0f, 1.0f);
 
                    GL.End();
 
                    game.SwapBuffers();
                };
 
                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }
    }
}