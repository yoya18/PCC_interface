  
    /*
  * rt_nonfinite.c
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


      

    /*
  * Abstract:
  *      Function to intialize non-finites,
  *      (Inf, NaN and -Inf).
  */
    #include "rt_nonfinite.h"

          #include "rtGetNaN.h"
        #include "rtGetInf.h"
    

    

  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
    
  
    real_T rtInf;
      real_T rtMinusInf;
      real_T rtNaN;
    
    real32_T rtInfF;
      real32_T rtMinusInfF;
      real32_T rtNaNF;
  
  
    
  /* 
 * Initialize the rtInf, rtMinusInf, and rtNaN needed by the
 * generated code. NaN is initialized as non-signaling. Assumes IEEE.
 */

    void rt_InitInfAndNaN(size_t realSize) {

    (void) (realSize); 
    rtNaN = rtGetNaN();
    rtNaNF = rtGetNaNF();
    rtInf = rtGetInf();
    rtInfF = rtGetInfF();
    rtMinusInf = rtGetMinusInf();
    rtMinusInfF = rtGetMinusInfF();
  }
    
  /* Test if value is infinite */
    boolean_T rtIsInf(real_T value) {
    return (boolean_T)((value==rtInf || value==rtMinusInf) ? 1U : 0U);
  }
    
  /* Test if single-precision value is infinite */
    boolean_T rtIsInfF(real32_T value) {
    return (boolean_T)(((value)==rtInfF || (value)==rtMinusInfF) ? 1U : 0U);
  }
    
  /* Test if value is not a number */
    boolean_T rtIsNaN(real_T value) {
      return (boolean_T)((value!=value) ? 1U : 0U);
  }
    
  /* Test if single-precision value is not a number */
    boolean_T rtIsNaNF(real32_T value) {
      return (boolean_T)(((value!=value) ? 1U : 0U));
  }
    

  
  
  
  
  
  
  
  
