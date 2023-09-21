/*
 * env_setting.h
 *
 *  Created on: 2023/09/20
 *      Author: dai
 */
#ifndef ARCHIVE_ECLIPSE_SETTING_H_
#define ARCHIVE_ECLIPSE_SETTING_H_

// all env setting
#define ECLIPSE_ENV 1

//#include "eclipse_macro.h"

// MACRO function
#if (ECLIPSE_ENV)
#define eclipse_printf PRINTF_FLUSH
#define PRINTF_FLUSH(fmt, ...) do { \
    printf(fmt, ##__VA_ARGS__);     \
    fflush(stdout);                \
} while (0)
#else
#define eclipse_printf printf
#endif

#endif /* ARCHIVE_ECLIPSE_SETTING_H_ */

