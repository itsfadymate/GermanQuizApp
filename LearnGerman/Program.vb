' Created by SharpDevelop.
' User: bassem
' Date: 5/29/2022
' Time: 8:24 AM
'
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Module Program
	
	Public AdjectivesUpperBound As Integer
	Public NounsUpperBound As Integer
	Public VerbsUpperBound As Integer
	Public ExpressionsUpperBound as integer 
	Public TotalPossibleScore as Integer
	
	Sub Main()
		try
			Dim userin As String
			Dim Fortfahren,Confirm As Char
			Dim Score As Double
			Dim QuestionsAsked As Integer = 0
			Dim FalseAnswers As New List(Of QandA)
			Dim Time = DateTime.Now
			
			
		    Console.WriteLine(Time)
			Dim FileAdjectives As String = "E:\lots of folders\fady stuff\IGCSE\German\CodeAccess\AdjectivesA1.txt"
			AdjectivesUpperBound = FindNoOfLines(FileAdjectives)
			Dim Adjectives(AdjectivesUpperBound) As QandA
			LoadFileIntoArray(FileAdjectives,Adjectives)
			
			
			Dim FileNouns As String = "E:\lots of folders\fady stuff\IGCSE\German\CodeAccess\NounsA1.txt"
			NounsUpperBound = FindNoOfLines(FileNouns)
			Dim Nouns(NounsUpperBound) As QandA
			LoadFileIntoArray(FileNouns,Nouns)
			
			
			Dim FileVerbs As String = "E:\lots of folders\fady stuff\IGCSE\German\CodeAccess\VerbsA1.txt"
			VerbsUpperBound = FindNoOfLines(FileVerbs)
			Dim Verbs(VerbsUpperBound) As QandA
			LoadFileIntoArray(FileVerbs,Verbs)
			
			Dim FileExpressions As String = "E:\lots of folders\fady stuff\IGCSE\German\CodeAccess\Expressions.txt"
			ExpressionsUpperBound = FindNoOfLines(FileExpressions)
			Dim Expressions(ExpressionsUpperBound) As QandA
			LoadFileIntoArray(FileExpressions,Expressions)
			
			
			Do
			console.WriteLine("Do you want casual or rigorous testing?")
			userin = console.ReadLine()
			While (left(userin,6).ToLower <> "casual" And left(userin,8).ToLower <>"rigorous")
				console.WriteLine("testing method unclear, enter either casual or rigorous")
				userin = console.ReadLine()
			End While
			
			
			If (left(userin,6).ToLower = "casual") Then
				Score = AskCasual(Adjectives,Nouns,Verbs,Expressions)
				
				Console.WriteLine("Your score is : " & Score &" out of " & TotalPossibleScore)
				
			ElseIf (left(userin,8).ToLower ="rigorous")
				
				Score = AskRigorous(Adjectives,Nouns,Verbs,Expressions,FalseAnswers)
				Console.WriteLine("")
				Console.WriteLine("Your score is : " & Score &" out of " & TotalPossibleScore) 
				Console.WriteLine("")
				AddScore(Score)
				
				Time = DateTime.Now
				Console.WriteLine(Time)
				
				AskRigorousHelper(FalseAnswers,FalseAnswers.Count-1)
				
				Time = DateTime.Now
				Console.WriteLine(Time)
			End If
			Do
			Console.WriteLine("")
			Console.WriteLine("Mochten sie fortfahren?(Do you want to continue?)")
			Console.Write(" -Enter either " & Chr(34) &  "y" & Chr(34) &" for yes or "& Chr(34) & "N" & Chr(34) &" for No: ")
			Fortfahren = Char.Parse(Console.ReadLine())
			Console.WriteLine("")
			Console.WriteLine("Sind sie sicher?(Are you sure?)")
			Console.Write(" -Enter either " & Chr(34) &  "y" & Chr(34) &" for yes or "& Chr(34) & "N" & Chr(34) &" for No: ")
			Confirm = Char.Parse(Console.ReadLine())
			Loop Until Confirm = "y"
			
			
			Loop Until Fortfahren <> "y"
		Catch ex As Exception
			console.WriteLine(ex)
		end try
		
		
		
		
		
		' TODO: Implement Functionality Here
		'Fix Spacing Errors
		'Display and save how long it took to finish rigorous testing
		
		
		Console.Write("Press any key to continue . . . ")
		Console.ReadKey(True)
	End Sub
	
	Function FindNoOfLines(FileName as String) As Integer 'Starts counting from 0
		Dim NoOfLines As Integer = -1
		Dim FileData as string 
		fileopen(1,FileName, OpenMode.Input)
		While Not EOF(1)
			Input(1,FileData)
			If Not (String.IsNullOrEmpty(FileData))
				NoOfLines = NoOflines + 1
			End If	
			
			
		end while
		fileClose(1)
		Return NoOfLines
	End Function
	
	sub LoadFileIntoArray(FileName As String,ByRef Array() As QandA)
		
		fileopen(1,FileName, OpenMode.Input)
		
		
		Dim Index As Integer = 0
		Dim FileData as String
		Dim Gender As String = "E"
		Dim GermanWord As String
		Dim EnglishWord As String
		Dim i,j As Integer
		While Not EOF(1)
			
			Germanword = ""
			Englishword = ""
			Input(1,FileData)
			If Not (String.IsNullOrEmpty(FileData))
				i = 1
				While MID(Filedata,i,2) <>" :"
					GermanWord = GermanWord & MID(FileData,i,1)
					i = i + 1
				End While
				
				j = i + 3
				
				While j <> Filedata.Length + 1 And MID(Filedata,j,1) <> "("
					EnglishWord = EnglishWord & MID(FileData,j,1)
					
					If MID(Filedata,j,3).ToUpper = "(M)" Then
						Gender = "M"
					elseif MID(Filedata,j,3).ToUpper = "(F)"
						Gender = "F"
					elseif MID(Filedata,j,3).ToUpper = "(N)"
						Gender = "N"
					End If
					
					j = j + 1
				End While
				
				If Gender <> "E" Then
					Array(index) = New QandA(GermanWord,EnglishWord,Char.Parse(Gender))
				Else
					Array(Index) = New QandA(GermanWord,EnglishWord)
				end if
				Index = Index + 1
			End if 
		End While
		fileClose(1)
	End Sub
	
	Function AskCasual( Array1() As QandA,Array2() As QandA,Array3() As QandA,Array4() As QandA) as Double
		Dim Score As Double = 0
		Dim QuestionsAsked As Integer = 0
		TotalPossibleScore = 0
		Dim r As New Random
		Dim QuestionNumToAsk,FileNum,EnglishOrGerman,RandomIndex As Integer
		
		QuestionNumToAsk = int(r.Next(6,18))
		
		WHILE QuestionsAsked <> QuestionNumToAsk
			TotalPossibleScore = TotalPossibleScore + 1
			FileNum = int(r.Next(1,5))
			EnglishOrGerman = int(r.Next(0,2))
			
			If FileNum = 1 Then
				
				
				RandomIndex = r.Next(0,AdjectivesUpperBound)
				If EnglishOrGerman = 0 Then
					Console.Write("Translate " & Array1(RandomIndex).GetEnglishWord & " to german : ")
					Score = Score + CheckAnswer(Array1(RandomIndex).GetGermanWord,Array1(RandomIndex).GetEnglishWord)
				Else
					Console.Write("Translate " & Array1(RandomIndex).GetGermanWord & " to English : ")
					Score = Score + CheckAnswer(Array1(RandomIndex).GetEnglishWord,Array1(RandomIndex).GetGermanWord)
				end if
				
				
			ElseIf FileNum = 2
				
				
				RandomIndex = r.Next(0,NounsUpperBound)
				If EnglishOrGerman = 0 Then
					Console.Write("Translate " & Array2(RandomIndex).GetEnglishWord & " to german : ")
					Score = Score + CheckAnswer(Array2(RandomIndex).GetGermanWord,Array2(RandomIndex).GetEnglishWord)
					'Add Question to check if masculine or feminene later
				Else
					Console.Write("Translate " & Array2(RandomIndex).GetGermanWord & " to English : ")
					Score = Score + CheckAnswer(Array2(RandomIndex).GetEnglishWord,Array2(RandomIndex).GetGermanWord)
				End If
				
				
			ElseIf FileNum = 3
				
				
				RandomIndex = r.Next(0,VerbsUpperBound)
				If EnglishOrGerman = 0 Then
					Console.Write("Translate " & Array3(RandomIndex).GetEnglishWord & " to german : ")
					Score = Score + CheckAnswer(Array3(RandomIndex).GetGermanWord,Array3(RandomIndex).GetEnglishWord)
				Else
					Console.Write("Translate " & Array3(RandomIndex).GetGermanWord & " to English : ")
					Score = Score + CheckAnswer(Array3(RandomIndex).GetEnglishWord,Array3(RandomIndex).GetGermanWord)
				End If
				
			Else
				
				
				RandomIndex = r.Next(0,ExpressionsUpperBound)
				If EnglishOrGerman = 0 Then
					Console.Write("Translate " & Array4(RandomIndex).GetEnglishWord & " to german : ")
					Score = Score + CheckAnswer(Array4(RandomIndex).GetGermanWord,Array4(RandomIndex).GetEnglishWord)
				Else
					Console.Write("Translate " & Array4(RandomIndex).GetGermanWord & " to English : ")
					Score = Score + CheckAnswer(Array4(RandomIndex).GetEnglishWord,Array4(RandomIndex).GetGermanWord)
				End If
				
			End If
			QuestionsAsked = QuestionsAsked + 1
			
		End While
		Return score
	End Function
	
	Function AskRigorous( Array1() As QandA,Array2() As QandA,Array3() As QandA,Array4() as QandA,byref FalseAnswers As List(Of QandA)) As Double
		
		Dim Score As Double = 0
		
		totalpossiblescore = 0
		
		Dim Asked1(AdjectivesUpperBound) As Boolean
		
		Dim Asked2(NounsUpperBound) As Boolean
		
		Dim Asked3(VerbsUpperBound) As Boolean
		
		Dim Asked4(ExpressionsUpperBound) As Boolean
		
		AskRigorousHelper(Array1,AdjectivesUpperBound,Score,FalseAnswers)
		
		AskRigorousHelper(Array2,NounsUpperBound,Score,FalseAnswers)
		
		AskRigorousHelper(Array3,VerbsUpperBound,Score,FalseAnswers)
		
		AskRigorousHelper(Array4,ExpressionsUpperBound,Score,FalseAnswers)
		
		Return Score
		
	End Function
	
	Sub InitialiseArray(ByRef Array() As Boolean,Ub as Integer)
		Dim i As Integer
		For i = 0 To ub
			Array(i)= false
		next
	end sub
	
	Sub AskRigorousHelper(Array() As QandA, ub As Integer,ByRef Score As Double,ByRef FalseAnswers As List(Of QandA))
		Dim r As New Random
		Dim ObtainedScore As Double
		Dim EnglishOrGerman,Temp As Integer
		Dim Asked(ub) As Boolean
		InitialiseArray(Asked,ub)
		
		For i = 0 To ub
			totalPossiblescore = totalpossiblescore + 1
			EnglishOrGerman = int( r.Next(0,2))
			
			Do
				temp = int( r.Next(0,ub+1))
			Loop Until Asked(temp) = False
			Asked(temp) = True
			
			If EnglishOrGerman = 0 Then
				Console.Write("Translate " & Array(Temp).GetEnglishWord & " to german : ")
				ObtainedScore = CheckAnswer(Array(Temp).GetGermanWord,Array(Temp).GetEnglishWord)
				Score = Score + ObtainedScore
				
			Else
				Console.Write("Translate " & Array(Temp).GetGermanWord & " to English : ")
				ObtainedScore = CheckAnswer(Array(Temp).GetEnglishWord,Array(Temp).GetGermanWord)
				Score = Score + ObtainedScore
			End If
			
			If ObtainedScore <> 1 Then
				FalseAnswers.Add(Array(Temp))
			End If

		Next
		
		    
	End Sub 
	
	Sub AskRigorousHelper(List as List(Of QandA), ub as integer)
		dim r as new random
		Dim EnglishOrGerman,Temp As Integer
		Dim i As Integer =0
		Dim Asked(ub) As Boolean
		InitialiseArray(Asked,ub)
		
		For i = 0 To ub
			
			
			EnglishOrGerman = int( r.Next(0,2))
			
			Do
				temp = int( r.Next(0,ub+1))
			Loop Until (Asked(temp) = False) 
			
			
			Asked(temp) = True
			If EnglishOrGerman = 0 Then
				Console.Write("Translate " & List(Temp).GetEnglishWord & " to german : ")
			    CheckAnswer(List(Temp).GetGermanWord,List(Temp).GetEnglishWord)
				
			Else
				Console.Write("Translate " & List(Temp).GetGermanWord & " to English : ")
				CheckAnswer(List(Temp).GetEnglishWord,List(Temp).GetGermanWord)
				
			End If
	
		Next
		
		    
	End Sub 
	
	Function CheckAnswer(Word As String, OtherWord As String) As Double
		Dim Score As Double
		Dim TrialNumber as Integer = 1
		Dim UserAnswer As String = ""
		Dim NoSpaceWord1 As String = ""
		Dim Word1 As String = ""
		Dim AlternativePresent As Boolean = False
		Dim NoSpaceWord2 As String =""
		Dim Word2 As String =""
		Dim Ub As Integer = Word.Length()
		Dim i As Integer
		
		Word = Word.TrimStart
		Word = Word.TrimEnd
		For i = 1 To Ub
			
			If (Mid(Word,i,1) <> "/") And (AlternativePresent = False) Then
				
				
				Word1 = Word1 & Mid(word,i,1)
				
				If Mid(Word,i,1) <> " " Then
					NoSpaceWord1 = NoSpaceWord1 & Mid(word,i,1)
				End If
				
				
			ElseIf AlternativePresent =True
				
				Word2 = Word2 & Mid(word,i,1)
				
				If Mid(Word,i,1) <> " " Then
					NoSpaceWord2 = NoSpaceWord2 & Mid(word,i,1)
				End If
			Else
				AlternativePresent = True
				
			End If
			
		Next
		
		Do
			
			If TrialNumber = 1 Then
				UserAnswer = Console.ReadLine()
				If (UserAnswer.Trim = "") Then
					Console.CursorTop = Console.CursorTop - 1
					Console.CursorLeft = Len("Translate to English :" ) + Len(OtherWord.Trim) + 1
					Console.Write(" " & Word)
					Console.WriteLine("")
					
				End If
				score = 1
			Else
				Console.Write("  Answer is incorrect, re-try or enter""idk"" if you give up : ")
				UserAnswer = Console.ReadLine()
				If (UserAnswer.Trim = "") Then
					Console.CursorTop = Console.CursorTop - 1
					Console.CursorLeft = Len("  Answer is incorrect, re-try or enter""idk"" if you give up : ") -1 
					Console.Write(" " & Word)
					Console.WriteLine("")
					
				End If
				If Trialnumber = 2
					score = 0.75
				ElseIf TrialNumber = 3
					Score = 0.5
				Elseif TrialNumber = 4
					Score = 0.25
				Else
					Score = 0.1
				End If
			End If
			If userAnswer.ToLower = "idk" Then
				Console.WriteLine("  The CorrectAnswer is : " & word )
				Score = 0
			End IF
			TrialNUmber = TrialNUmber + 1
			
		Loop Until (UserAnswer.ToLower = "idk") Or (UserAnswer.ToLower = Word1.ToLower) or (userAnswer.ToLower = word2.ToLower) Or (UserAnswer.ToLower = NoSpaceWord1.ToLower) or (UserAnswer.ToLower = NoSpaceWord2.ToLower) Or (UserAnswer.Trim = "")
		
		
		return score
		
	End Function
	
	
	Sub AddScore(Score As Double)       
		Dim Percentage As Double
		Percentage = (Score/TotalPossibleScore)*100
		
		Dim FileData As String = Score &" out of " &TotalPossibleScore &"(" & Left(CStr(Percentage),4) &"%)"
		FileOpen(1,"E:\lots of folders\fady stuff\IGCSE\German\CodeAccess\ZRigorousScores.txt", OpenMode.Append)
		WriteLine(1,FileData)
		FileClose(1)
	End Sub
	
	
End Module