Module Module1

   Sub Main()
      Dim emoList As New List(Of emot)
      Dim s As String = ""
      Using rdr As System.IO.StreamReader = New System.IO.StreamReader("C:\TEMP\em.txt")
         s = rdr.ReadToEnd()
         s = s.Substring(s.IndexOf("}") + 1, s.Length - s.IndexOf("}") - 1)
      End Using

      While s.Contains("regex")
         Dim em As New emot
         Dim dat As String = ""
         dat = s.Substring(s.IndexOf("regex") + 8)
         dat = dat.Substring(0, dat.IndexOf(",") - 1)
         em.name = dat
         dat = s.Substring(s.IndexOf("url") + 6)
         dat = dat.Substring(0, dat.IndexOf("}") - 1)

         em.url = dat
         s = s.Substring(s.IndexOf("}") + 1, s.Length - s.IndexOf("}") - 1)
         If em.name.Contains("\") Then
            Continue While
         End If
         emoList.Add(em)
      End While

      Using writer As System.IO.StreamWriter = New System.IO.StreamWriter("C:\TEMP\me.txt")
         For Each line As emot In emoList
            writer.WriteLine("INSERT INTO `emotes`(`name`, `url`) VALUES ('" & line.name & "','" & line.url & "');")
         Next
      End Using

   End Sub

End Module

Public Class emot

   Public url As String = ""
   Public name As String = ""

End Class