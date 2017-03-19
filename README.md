# kodi-on-imon
Displaying media info from Kodi 17 on Imon VF310 VFD
Tested on windows 7, 8 and 10

1 - Installation
1) Install imon software version 8.12.1202. I was only able to find it here http://www.origenae.co.kr/board/bbs/board.php?bo_table=e_pds&wr_id=118
2) Enable plugin mode in imon
3) Enable Front View in imon
4) Disable all information sources in Front View (resulting only the time is shown on display)
5) Open the project in Visual Studio (both version 2013 and 2015 work for me) and compile/build it
6) To make the project work, place the displaywrapper files (Kodi-on-iMon\iMonDisplayApi) in the same folder as the compiled exe file.

2 - Credits
1) Project that was my inspiration to start with my current project: https://sourceforge.net/projects/imondisplayapiexamplevbnet/
2) imon displaywrapper: https://sourceforge.net/projects/imonapi-sharp
