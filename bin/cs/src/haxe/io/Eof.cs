// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.io {
	public class Eof : global::haxe.lang.HxObject {
		
		public Eof(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Eof() {
			global::haxe.io.Eof.__hx_ctor_haxe_io_Eof(this);
		}
		
		
		protected static void __hx_ctor_haxe_io_Eof(global::haxe.io.Eof __hx_this) {
		}
		
		
		public virtual string toString() {
			return "Eof";
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
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
					case 946786476:
					{
						return this.toString();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}


