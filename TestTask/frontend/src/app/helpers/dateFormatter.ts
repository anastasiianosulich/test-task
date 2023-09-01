const fullDateOptions: Intl.DateTimeFormatOptions = {
  year: 'numeric', // 'numeric' for the year like 2023
  month: '2-digit', // '2-digit' for zero-padded month like 08
  day: '2-digit', // '2-digit' for zero-padded day like 06
  hour: '2-digit', // '2-digit' for zero-padded hours like 12
  minute: '2-digit', // '2-digit' for zero-padded minutes like 34
  second: '2-digit', // '2-digit' for zero-padded seconds like 56
  hour12: false,
};

const dateOnlyOptions: Intl.DateTimeFormatOptions = {
  year: 'numeric', // 'numeric' for the year like 2023
  month: '2-digit', // '2-digit' for zero-padded month like 08
  day: '2-digit', // '2-digit' for zero-padded day like 06
};

export function formatDateStr(dateString: string): string {
  const givenDate = new Date(dateString);
  return givenDate.toLocaleString('en-US', fullDateOptions);
}

export function formatDateWithoutTime(dateString: string): string {
  const givenDate = new Date(dateString);
  return givenDate.toLocaleString('en-US', dateOnlyOptions);
}
