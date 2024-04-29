' Created by SharpDevelop.
' User: bassem
' Date: 5/29/2022
' Time: 8:24 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Public Class QandA
	Private GermanWord As String
	Private EnglishWord As String
	Private Gender as Char
	
	
	
	Public Sub New(germanWord As String,englishword As String)
		Me.GermanWord = germanWord
		Me.EnglishWord = englishword
	End Sub
	Public Sub New(germanWord As String,englishword As String,Gender as Char)
		Me.GermanWord = germanWord
		Me.EnglishWord = englishword
		me.Gender = Gender
	End Sub
	
	
	Public Sub SetGermanWord(GW As String)
		me.GermanWord = GW
	End Sub
	
	Public function GetGermanWord() As String
		Return GermanWord
	End Function
	
	Public Function GetEnglishWord() As String
		return EnglishWord
	End Function
	
	Public Sub SetEnglishWord(EW As String)
		me.EnglishWord = EW
	End Sub
	
	
	
	Public Function GetGender() As Char
		return me.Gender
	End Function
	
	Public Sub SetGender(MFN As Char)
		me.Gender = MFN
	End Sub
End Class