﻿using System;
using System.Xml.Serialization;
using Hudl.Ffmpeg.Resources;
using Hudl.Ffmpeg.Resources.BaseTypes;
using Hudl.Ffmpeg.Sugar;
using Hudl.Ffmpeg.Tests.Assets;
using Xunit; 

namespace Hudl.Ffmpeg.Tests.Resources
{
    public class ResourceTests
    {
        public ResourceTests()
        {
            Utilities.SetGlobalAssets();
        }

        [Fact]
        public void IVideo_CreateEmpty_SettingsSet()
        {
            var resource = ResourceFactory.CreateEmpty<Mp4>();

            Assert.NotEmpty(resource.Id);
            Assert.NotEmpty(resource.Name);
        }

        [Fact]
        public void IAudio_CreateEmpty_SettingsSet()
        {
            var resource = ResourceFactory.CreateEmpty<Mp3>();

            Assert.NotEmpty(resource.Id);
            Assert.NotEmpty(resource.Name);
        }

        [Fact]
        public void IImage_CreateEmpty_SettingsSet()
        {
            var resource = ResourceFactory.CreateEmpty<Png>();

            Assert.NotEmpty(resource.Id);
            Assert.NotEmpty(resource.Name);
        }

        [Fact]
        public void IVideo_CreateWithPath_SettingsSet()
        {
            const string path = "c:/source/";
            const string name = "apples.mp4";
            const string fullName = path + name;
            var resource = Resource.Create<Mp4>(fullName);

            Assert.NotEmpty(resource.Id);
            Assert.Equal(resource.Name, name);
            Assert.Equal(resource.Path, path);
            Assert.Equal(resource.FullName, fullName);
        }

        [Fact]
        public void IAudio_CreateWithPath_SettingsSet()
        {
            const string path = "c:/source/";
            const string name = "apples.mp3";
            const string fullName = path + name;
            var resource = Resource.Create<Mp3>(fullName);

            Assert.NotEmpty(resource.Id);
            Assert.Equal(resource.Name, name);
            Assert.Equal(resource.Path, path);
            Assert.Equal(resource.FullName, fullName);
        }

        [Fact]
        public void IVideo_CreateWithPathAndLength_SettingsSet()
        {
            const string path = "c:/source/";
            const string name = "apples.mp4";
            const string fullName = path + name;
            var resource = Resource.Create<Mp4>(fullName);

            Assert.NotEmpty(resource.Id);
            Assert.Equal(resource.Name, name);
            Assert.Equal(resource.Path, path);
            Assert.Equal(resource.FullName, fullName);
        }

        [Fact]
        public void IAudio_CreateWithPathAndLength_SettingsSet()
        {
            const string path = "c:/source/";
            const string name = "apples.mp3";
            const string fullName = path + name;
            var resource = Resource.Create<Mp3>(fullName);

            Assert.NotEmpty(resource.Id);
            Assert.Equal(resource.Name, name);
            Assert.Equal(resource.Path, path);
            Assert.Equal(resource.FullName, fullName);
        }

        [Fact]
        public void IVideo_CreateWithBadPath_ThrowsException()
        {
            const string pngPathName = "c:/source/apples.png";
            
            Assert.Throws<ArgumentException>(() => Resource.Create<Mp4>(pngPathName));
        }

        [Fact]
        public void IAudio_CreateWithBadPath_ThrowsException()
        {
            const string pngPathName = "c:/source/apples.png";

            Assert.Throws<ArgumentException>(() => Resource.Create<Mp3>(pngPathName));
        }

        [Fact]
        public void CustomType_Verify()
        {
            const string mkvPathName = "c:/source/apples.mkv";

            Assert.DoesNotThrow(() => Resource.From(mkvPathName));
        }

        private class ResourceFactory
        {
            public static TResource CreateEmpty<TResource>()
                where TResource : class, IContainer, new()
            {
                return new TResource();
            }
        }
    }
}
