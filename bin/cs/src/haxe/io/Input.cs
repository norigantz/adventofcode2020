// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.io {
	public class Input : global::haxe.lang.HxObject {
		
		public Input(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Input() {
			global::haxe.io.Input.__hx_ctor_haxe_io_Input(this);
		}
		
		
		protected static void __hx_ctor_haxe_io_Input(global::haxe.io.Input __hx_this) {
		}
		
		
		public virtual int readByte() {
			throw ((global::System.Exception) (global::haxe.Exception.thrown("Not implemented")) );
		}
		
		
		public virtual int readBytes(global::haxe.io.Bytes s, int pos, int len) {
			int k = len;
			byte[] b = s.b;
			if (( ( ( pos < 0 ) || ( len < 0 ) ) || ( ( pos + len ) > s.length ) )) {
				throw ((global::System.Exception) (global::haxe.Exception.thrown(global::haxe.io.Error.OutsideBounds)) );
			}
			
			try {
				while (( k > 0 )) {
					b[pos] = ((byte) (this.readByte()) );
					 ++ pos;
					 -- k;
				}
				
			}
			catch (global::System.Exception _g){
				if (( ((object) (global::haxe.Exception.caught(_g).unwrap()) ) is global::haxe.io.Eof )) {
				}
				else {
					throw _g;
				}
				
			}
			
			
			return ( len - k );
		}
		
		
		public virtual global::haxe.io.Bytes readAll(global::haxe.lang.Null<int> bufsize) {
			unchecked {
				if ( ! (bufsize.hasValue) ) {
					bufsize = new global::haxe.lang.Null<int>(16384, true);
				}
				
				global::haxe.io.Bytes buf = global::haxe.io.Bytes.alloc((bufsize).@value);
				global::haxe.io.BytesBuffer total = new global::haxe.io.BytesBuffer();
				try {
					while (true) {
						int len = this.readBytes(buf, 0, (bufsize).@value);
						if (( len == 0 )) {
							throw ((global::System.Exception) (global::haxe.Exception.thrown(global::haxe.io.Error.Blocked)) );
						}
						
						{
							if (( ( len < 0 ) || ( len > buf.length ) )) {
								throw ((global::System.Exception) (global::haxe.Exception.thrown(global::haxe.io.Error.OutsideBounds)) );
							}
							
							( total.b as global::System.IO.Stream ).Write(((byte[]) (buf.b) ), ((int) (0) ), ((int) (len) ));
						}
						
					}
					
				}
				catch (global::System.Exception _g){
					if (( ((object) (global::haxe.Exception.caught(_g).unwrap()) ) is global::haxe.io.Eof )) {
					}
					else {
						throw _g;
					}
					
				}
				
				
				return total.getBytes();
			}
		}
		
		
		public virtual string readLine() {
			unchecked {
				global::haxe.io.BytesBuffer buf = new global::haxe.io.BytesBuffer();
				int last = default(int);
				string s = null;
				try {
					while (true) {
						last = this.readByte();
						if ( ! ((( last != 10 ))) ) {
							break;
						}
						
						( buf.b as global::System.IO.Stream ).WriteByte(((byte) (last) ));
					}
					
					s = buf.getBytes().toString();
					if (global::haxe.lang.Runtime.eq((global::haxe.lang.StringExt.charCodeAt(s, ( s.Length - 1 ))).toDynamic(), 13)) {
						s = global::haxe.lang.StringExt.substr(s, 0, new global::haxe.lang.Null<int>(-1, true));
					}
					
				}
				catch (global::System.Exception _g){
					object _g1 = global::haxe.Exception.caught(_g).unwrap();
					if (( _g1 is global::haxe.io.Eof )) {
						global::haxe.io.Eof e = ((global::haxe.io.Eof) (_g1) );
						{
							s = buf.getBytes().toString();
							if (( s.Length == 0 )) {
								throw ((global::System.Exception) (global::haxe.Exception.thrown(e)) );
							}
							
						}
						
					}
					else {
						throw _g;
					}
					
				}
				
				
				return s;
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1873474154:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "readLine", 1873474154)) );
					}
					
					
					case 46374763:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "readAll", 46374763)) );
					}
					
					
					case 243225909:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "readBytes", 243225909)) );
					}
					
					
					case 1763375486:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "readByte", 1763375486)) );
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, object[] dynargs) {
			unchecked {
				switch (hash) {
					case 1873474154:
					{
						return this.readLine();
					}
					
					
					case 46374763:
					{
						return this.readAll(global::haxe.lang.Null<object>.ofDynamic<int>(( (( dynargs.Length > 0 )) ? (dynargs[0]) : (null) )));
					}
					
					
					case 243225909:
					{
						return this.readBytes(((global::haxe.io.Bytes) (dynargs[0]) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[1])) ), ((int) (global::haxe.lang.Runtime.toInt(dynargs[2])) ));
					}
					
					
					case 1763375486:
					{
						return this.readByte();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
	}
}


