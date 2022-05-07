require random.fs

variable ard

3 Constant cam-total
create cams 3 cells allot

: iard-connect ( -- ) 0 ;
: ard-step ( inc -- ) drop ;
: icamera-connect ( -- ) s" gphoto2" system 0 ;
: shoot ( a -- n )
    drop rnd ;
    