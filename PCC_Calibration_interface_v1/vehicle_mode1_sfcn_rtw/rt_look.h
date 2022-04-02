/*
 * rt_look.h
 *
 * Code generation for model "vehicle_mode1_sf".
 *
 * Model version              : 1.70
 * Simulink Coder version : 8.9 (R2015b) 13-Aug-2015
 * C source code generated on : Sat Aug 24 14:17:19 2019
 *
 * Target selection: rtwsfcn.tlc
 * Note: GRT includes extra infrastructure and instrumentation for prototyping
 * Embedded hardware selection: 32-bit Generic
 * Emulation hardware selection:
 *    Differs from embedded hardware (MATLAB Host)
 * Code generation objectives: Unspecified
 * Validation result: Not run
 */

#ifndef RTW_HEADER_rt_look_h_
#define RTW_HEADER_rt_look_h_
#include "rtwtypes.h"
#ifdef DOINTERPSEARCH
#include <float.h>
#endif

#ifndef INTERP
# define INTERP(x,x1,x2,y1,y2)         ( (y1)+(((y2) - (y1))/((x2) - (x1)))*((x)-(x1)) )
#endif

#ifndef ZEROTECHNIQUE
#define ZEROTECHNIQUE

typedef enum {
  NORMAL_INTERP,
  AVERAGE_VALUE,
  MIDDLE_VALUE
} ZeroTechnique;

#endif

extern int_T rt_GetLookupIndex(const real_T *x, int_T xlen, real_T u) ;

#endif                                 /* RTW_HEADER_rt_look_h_ */
