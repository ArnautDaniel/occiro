include conn.fs
include emul.fs

create obj-name 255 chars allocate throw .

: ard-connect ( -- )
    cr s" Connecting to Arduino..." type
    iard-connect throw s" ok" type ;

: camera-connect ( -- )
    cr s" Connecting to Cameras..." type
    icamera-connect throw s" ok" type ;

: connect-to ( -- )
    ard-connect camera-connect ;

: then-present ( -- )
    cr s" Object Name? " type
    obj-name 255 accept
    cr obj-name swap type ;

: and-capture ( -- )
    begin
	table-state @ 360 <=  while
	    capture-then rotate
    repeat
    0 table-state ! ;

: powpri ( -- )
    cr s" POWPRI v0.1" type
    connect-to then-present and-capture ;