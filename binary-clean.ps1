echo bin,obj,deploy,FakesAssemblies,.vs,packages,debug,x86,x64 -rec
gci -inc bin,obj,deploy,FakesAssemblies,.vs,packages,debug,x86,x64 -rec | rm -rec -force