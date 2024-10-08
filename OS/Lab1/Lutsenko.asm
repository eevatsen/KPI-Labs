title lab1.asm

.MODEL tiny
.DATA

; byte
i db 0, 255
i1 db -255         
ii db -128, 127

; my values (byte)
   db 156
   db 138
   db -138
  

; word
r0 dw -255         
r dw 0, 65535
r1 dw -1, -32768
r2 dw 1, 32767 
r3 dw -65535        
r4 dd -65535

; my values (word)
   dw -156
   dw 1333
   dw 1315
   dw -1333
   dw -1315

end

