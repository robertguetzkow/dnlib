﻿using dot10.IO;

namespace dot10.dotNET {
	/// <summary>
	/// Reads the #~ compressed tables stream
	/// </summary>
	class CompressedTablesStream : TablesStream {
		/// <inheritdoc/>
		public CompressedTablesStream(IImageStream imageStream, StreamHeader streamHeader)
			: base(imageStream, streamHeader) {
		}
	}
}
