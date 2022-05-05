require conn.fs
variable table-state
10 Constant table-inc

create cam-data cam-total allocate throw .

: capture-camera ( a i -- )
    cam-data swap cells +
    swap shoot swap ! ;

: emulate-print ( -- )
    cam-total 0 u+do
	cam-data i cells + @
	cr s" Cam " type
	i u. u.
    loop ;
    
: capture-then ( -- )
    cam-total 0 u+do
	cams i cells + i
	capture-camera
    loop
    emulate-print ;

: rotate ( -- )
    table-state dup @ table-inc + swap !
    table-inc ard-step ;


