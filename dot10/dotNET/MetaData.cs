﻿using System.Collections.Generic;
using dot10.PE;

namespace dot10.dotNET {
	/// <summary>
	/// Common base class for #~ and #- metadata classes
	/// </summary>
	abstract class MetaData : IMetaData {
		/// <summary>
		/// The PE image
		/// </summary>
		protected IPEImage peImage;

		/// <summary>
		/// The .NET header
		/// </summary>
		protected ImageCor20Header cor20Header;

		/// <summary>
		/// The MD header
		/// </summary>
		protected MetaDataHeader mdHeader;

		/// <summary>
		/// The #Strings stream
		/// </summary>
		protected StringsStream stringsStream;

		/// <summary>
		/// The #US stream
		/// </summary>
		protected USStream usStream;

		/// <summary>
		/// The #Blob stream
		/// </summary>
		protected BlobStream blobStream;

		/// <summary>
		/// The #GUID stream
		/// </summary>
		protected GuidStream guidStream;

		/// <summary>
		/// The #~ or #- stream
		/// </summary>
		protected TablesStream tablesStream;

		/// <summary>
		/// All the streams that are present in the PE image
		/// </summary>
		protected List<DotNetStream> allStreams;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="peImage">The PE image</param>
		/// <param name="cor20Header">The .NET header</param>
		/// <param name="mdHeader">The MD header</param>
		protected MetaData(IPEImage peImage, ImageCor20Header cor20Header, MetaDataHeader mdHeader) {
			this.allStreams = new List<DotNetStream>();
			this.peImage = peImage;
			this.cor20Header = cor20Header;
			this.mdHeader = mdHeader;
			Initialize();
		}

		/// <summary>
		/// Initialize the metadata, tables, streams
		/// </summary>
		protected abstract void Initialize();

		/// <inheritdoc/>
		public void Dispose() {
			if (peImage != null)
				peImage.Dispose();
			if (stringsStream != null)
				stringsStream.Dispose();
			if (usStream != null)
				usStream.Dispose();
			if (blobStream != null)
				blobStream.Dispose();
			if (guidStream != null)
				guidStream.Dispose();
			if (tablesStream != null)
				tablesStream.Dispose();
			peImage = null;
			cor20Header = null;
			mdHeader = null;
			stringsStream = null;
			usStream = null;
			blobStream = null;
			guidStream = null;
			tablesStream = null;
			allStreams = null;
		}
	}
}
