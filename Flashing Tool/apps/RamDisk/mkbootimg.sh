#!/sbin/sh
cd /sdcard/
mkdir Repacked
cd /cache/tools/
chmod 755 ./mkbootimg.sh
chmod 755 ./mkbootimg
chmod 755 ./unpackbootimg
echo "Unpacking Kernels"
./unpackbootimg ./kernel_img/boot.img ./kernel_img/
./unpackbootimg ./ramdisk_img/boot.img ./ramdisk_img/
echo "Repacking Kernels"
echo ./mkbootimg --kernel ./kernel_img/boot.img-zImage --ramdisk ./ramdisk_img/boot.img-ramdisk.gz --cmdline \"$(cat ./ramdisk_img/boot.img-cmdline)\" --base $(cat ./ramdisk_img/boot.img-base) --output /sdcard/Repacked/repackedboot.img >> /cache/tools/createnewboot.sh
chmod 0775 ./createnewboot.sh
./createnewboot.sh
rm -r ../tools
echo "Complete"
