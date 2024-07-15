function valueOrDefault<T>(value: T | undefined, defaultValue: T) {
  return typeof value === 'undefined' ? defaultValue : value;
}