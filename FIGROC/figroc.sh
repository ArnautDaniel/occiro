#!/bin/bash
wd=$(zipinfo -1 $1 | grep -oE '^[^/]+' | uniq)
echo $wd
cp $1 "data/${wd}.zip"
unzip "data/${wd}.zip" -d "data/"
echo "data/${wd}/.*JPG"
cd "data/${wd}"
mm3d Tapioca MulScale ".*JPG" 500 2500
mm3d Tapas RadialStd  ".*JPG" Out=Output
mm3d AperiCloud ".*JPG" Output
