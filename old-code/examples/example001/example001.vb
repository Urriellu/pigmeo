Imports Pigmeo
Imports Pigmeo.Extensions
Imports Pigmeo.MCU

Module Module1
	Dim foo As Byte

	Sub Main()
		foo = Registers.PORTA
		While True
			foo += 1 'Note: by default this operation checks overflows, so Pigmeo Compiler doesn't generate exactly the same assembly language code for example001.cs and example001.vb
		End While
	End Sub

End Module
