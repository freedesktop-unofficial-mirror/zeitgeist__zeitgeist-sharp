/******************************************************************************
 * The MIT/X11/Expat License
 * Copyright (c) 2011 Manish Sinha<manishsinha@ubuntu.com>

 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE. 
********************************************************************************/

using System;
namespace Zeitgeist.Datamodel
{
	/// <summary>
	/// Represents a version number of format X.Y.Z (Major-Minor-Revision)
	/// </summary>
	/// <remarks>
	/// The fourth number(Patch) is ommitted
	/// </remarks>
	public class Version
	{
		public Version ()
		{
		}
		
		/// <summary>
		/// The major version section of a Version
		/// </summary>
		/// <remarks>
		/// X is the major version part of X.Y.Z
		/// </remarks>
		public string MajorVersion
		{
			get
			{
				return _majorVersion;
			}
			set
			{
				_majorVersion = value;
			}
		}
		
		/// <summary>
		/// The minor version section of a Version
		/// </summary>
		/// <remarks>
		/// Y is the minor version part of X.Y.Z
		/// </remarks>
		public string MinorVersion
		{
			get
			{
				return _minorVersion;
			}
			set
			{
				_minorVersion = value;
			}
		}
		
		/// <summary>
		/// The Revision section of a Version
		/// </summary>
		/// <remarks>
		/// Z is the Revision part of X.Y.Z
		/// </remarks>
		public string Revision
		{
			get
			{
				return _revision;
			}
			set
			{
				_revision = value;
			}
		}
		
		#region Private Members
		
		private string _majorVersion;
		
		private string _minorVersion;
		
		private string _revision;
		
		#endregion
	}
	
	internal struct RawVersion
	{
		public RawVersion(Version ver) : this()
		{
			this.MajorVersion = ver.MajorVersion;
			this.MinorVersion = ver.MinorVersion;
			this.Revision = ver.Revision;
		}
		
		public Version FromRaw()
		{
			Version ver = new Version();
			
			ver.MajorVersion = this.MajorVersion;
			ver.MinorVersion = this.MinorVersion;
			ver.Revision = this.Revision;
			
			return ver;
		}
		
		public string MajorVersion
		{
			get
			{
				return _majorVersion;
			}
			set
			{
				_majorVersion = value;
			}
		}
		
		public string MinorVersion
		{
			get
			{
				return _minorVersion;
			}
			set
			{
				_minorVersion = value;
			}
		}
		
		public string Revision
		{
			get
			{
				return _revision;
			}
			set
			{
				_revision = value;
			}
		}
		
		private string _majorVersion;
		
		private string _minorVersion;
		
		private string _revision;
	}
}

