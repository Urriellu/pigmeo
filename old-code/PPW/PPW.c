#include <sys/ioctl.h>
#include <linux/parport.h>
#include <linux/ppdev.h>
#include <fcntl.h>

int fd;

int Initialize(){
	fd = open("/dev/parport0", O_RDWR); //O_RDWR=2

	if (fd == -1) return 1;
	if (ioctl(fd, PPCLAIM, 0)==-1) return 2;

	//set mode
	int mode = IEEE1284_MODE_BYTE;
	if (ioctl(fd, PPSETMODE, &mode)==-1) {
		ioctl(fd, PPRELEASE);
		return 3;
	}

	// Set data pins to output
   int dir = 0x00;
   if (ioctl(fd, PPDATADIR, &dir)==-1) {
      ioctl(fd, PPRELEASE);
      close(fd);
      return 4;
   }

   return 0;
}

//Release and close the parallel port
void Close(){
	ioctl(fd, PPRELEASE);
	close(fd);
}

int WriteData(unsigned char value){
	return ioctl(fd, PPWDATA, &value);
}

int WriteControl(unsigned char value){
	return ioctl(fd, PPWCONTROL, &value);
}

unsigned char ReadStatus(){
	return ioctl(fd, PPRSTATUS);
}

//NOTE: the original libppw.so (not a soft link) has to be in the same directory as the application using it

/* TRY:

read/write pins:
PPWDATA
PPRDATA
PPRSTATUS
PPWCONTROL


IEEE1284 modes:
   Nibble mode, byte mode, ECP, ECPRLE and EPP are their own
   'extensibility request' values.  Others are special.
   'Real' ECP modes must have the IEEE1284_MODE_ECP bit set. 
#define IEEE1284_MODE_NIBBLE             0
#define IEEE1284_MODE_BYTE              (1<<0)
#define IEEE1284_MODE_COMPAT            (1<<8)
#define IEEE1284_MODE_BECP              (1<<9) /* Bounded ECP mode 
#define IEEE1284_MODE_ECP               (1<<4)
#define IEEE1284_MODE_ECPRLE            (IEEE1284_MODE_ECP | (1<<5))
#define IEEE1284_MODE_ECPSWE            (1<<10) /* Software-emulated 
#define IEEE1284_MODE_EPP               (1<<6)
#define IEEE1284_MODE_EPPSL             (1<<11) /* EPP 1.7 
#define IEEE1284_MODE_EPPSWE            (1<<12) /* Software-emulated 
#define IEEE1284_DEVICEID               (1<<2)  /* This is a flag 
#define IEEE1284_EXT_LINK               (1<<14) /* This flag causes the
                                                 * extensibility link to
                                                 * be requested, using
                                                 * bits 0-6. 
*/
